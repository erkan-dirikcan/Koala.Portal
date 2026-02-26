using AutoMapper;
using Koala.Portal.Core.DTOs;
using Koala.Portal.Core.Dtos;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Koala.Portal.WebUI.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectsController(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all projects with optional filtering and pagination
        /// </summary>
        [HttpGet]
        // [Authorize(Policy = "ProjectManagement.View")]
        public async Task<ActionResult<ApiResponse<PagedResponse<ProjectDto>>>> GetAll(
            [FromQuery] ProjectListQueryDto query)
        {
            var projectsResult = await _projectService.GetProjectListAsync();

            if (!projectsResult.IsSuccess)
            {
                return BadRequest(new ApiResponse<object>
                {
                    IsSuccess = false,
                    Message = projectsResult.Message
                });
            }

            var projects = projectsResult.Data;

            // Apply filters
            if (!string.IsNullOrEmpty(query.StatusFilter))
            {
                if (Enum.TryParse<ProjectStatusEnum>(query.StatusFilter, true, out var statusEnum))
                {
                    projects = projects.Where(p => p.ProjectStatus == statusEnum).ToList();
                }
            }

            // Manager and firm filters require project detail data - not implemented for list view
            if (!string.IsNullOrEmpty(query.SearchTerm))
            {
                projects = projects.Where(p =>
                    (p.ProjectName != null && p.ProjectName.Contains(query.SearchTerm, StringComparison.OrdinalIgnoreCase)) ||
                    (p.ProjectCode != null && p.ProjectCode.Contains(query.SearchTerm, StringComparison.OrdinalIgnoreCase)))
                    .ToList();
            }

            // Pagination
            var totalCount = projects.Count;
            var pagedProjects = projects
                .Skip((query.Page - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToList();

            var projectDtos = _mapper.Map<List<ProjectDto>>(pagedProjects);

            return Ok(new ApiResponse<PagedResponse<ProjectDto>>
            {
                IsSuccess = true,
                Data = new PagedResponse<ProjectDto>
                {
                    Items = projectDtos,
                    TotalCount = totalCount,
                    Page = query.Page,
                    PageSize = query.PageSize
                }
            });
        }

        /// <summary>
        /// Get a specific project by ID
        /// </summary>
        [HttpGet("{id}")]
        // [Authorize(Policy = "ProjectManagement.View")]
        public async Task<ActionResult<ApiResponse<ProjectDto>>> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest(new ApiResponse<object>
                {
                    IsSuccess = false,
                    Message = "Proje ID gereklidir"
                });
            }

            var projectResult = await _projectService.GetProjectByIdAsync(id);

            if (!projectResult.IsSuccess || projectResult.Data == null)
            {
                return NotFound(new ApiResponse<object>
                {
                    IsSuccess = false,
                    Message = "Proje bulunamadı"
                });
            }

            var projectDto = _mapper.Map<ProjectDto>(projectResult.Data);

            return Ok(new ApiResponse<ProjectDto>
            {
                IsSuccess = true,
                Data = projectDto
            });
        }

        /// <summary>
        /// Create a new project
        /// </summary>
        [HttpPost]
        // [Authorize(Policy = "ProjectManagement.Create")]
        public async Task<ActionResult<ApiResponse<ProjectDto>>> Create([FromBody] CreateProjectDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<object>
                {
                    IsSuccess = false,
                    Message = "Geçersiz veri",
                    Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()
                });
            }

            var viewModel = _mapper.Map<AddProjectViewModel>(dto);
            viewModel.CreateTime = DateTime.Now;

            var result = await _projectService.AddAsync(viewModel);

            if (!result.IsSuccess)
            {
                return BadRequest(new ApiResponse<object>
                {
                    IsSuccess = false,
                    Message = result.Message
                });
            }

            // Get the created project
            var projectResult = await _projectService.GetProjectByIdAsync(result.Data);
            var projectDto = _mapper.Map<ProjectDto>(projectResult.Data);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, new ApiResponse<ProjectDto>
            {
                IsSuccess = true,
                Message = "Proje başarıyla oluşturuldu",
                Data = projectDto
            });
        }

        /// <summary>
        /// Update an existing project
        /// </summary>
        [HttpPut("{id}")]
        // [Authorize(Policy = "ProjectManagement.Update")]
        public async Task<ActionResult<ApiResponse<ProjectDto>>> Update(string id, [FromBody] UpdateProjectDto dto)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest(new ApiResponse<object>
                {
                    IsSuccess = false,
                    Message = "Proje ID gereklidir"
                });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse<object>
                {
                    IsSuccess = false,
                    Message = "Geçersiz veri",
                    Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()
                });
            }

            var viewModel = _mapper.Map<UpdateProjectViewModel>(dto);
            viewModel.Id = id;
            viewModel.UpdateTime = DateTime.Now;

            var result = await _projectService.UpdateAsync(viewModel, id);

            if (!result.IsSuccess)
            {
                return BadRequest(new ApiResponse<object>
                {
                    IsSuccess = false,
                    Message = result.Message
                });
            }

            var projectDto = _mapper.Map<ProjectDto>(result.Data);

            return Ok(new ApiResponse<ProjectDto>
            {
                IsSuccess = true,
                Message = "Proje başarıyla güncellendi",
                Data = projectDto
            });
        }

        /// <summary>
        /// Delete a project
        /// </summary>
        [HttpDelete("{id}")]
        // [Authorize(Policy = "ProjectManagement.Delete")]
        public async Task<ActionResult<ApiResponse<object>>> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest(new ApiResponse<object>
                {
                    IsSuccess = false,
                    Message = "Proje ID gereklidir"
                });
            }

            var result = await _projectService.DeleteAsync(id);

            if (!result.IsSuccess)
            {
                return BadRequest(new ApiResponse<object>
                {
                    IsSuccess = false,
                    Message = result.Message
                });
            }

            return Ok(new ApiResponse<object>
            {
                IsSuccess = true,
                Message = "Proje başarıyla silindi"
            });
        }

        /// <summary>
        /// Get project lines for a specific project
        /// </summary>
        [HttpGet("{id}/lines")]
        // [Authorize(Policy = "ProjectManagement.View")]
        public async Task<ActionResult<ApiResponse<List<ProjectLineDto>>>> GetProjectLines(string id)
        {
            var projectResult = await _projectService.GetProjectByIdAsync(id);

            if (!projectResult.IsSuccess || projectResult.Data == null)
            {
                return NotFound(new ApiResponse<object>
                {
                    IsSuccess = false,
                    Message = "Proje bulunamadı"
                });
            }

            var lineDtos = _mapper.Map<List<ProjectLineDto>>(projectResult.Data.ProjectLines);

            return Ok(new ApiResponse<List<ProjectLineDto>>
            {
                IsSuccess = true,
                Data = lineDtos
            });
        }
    }
}

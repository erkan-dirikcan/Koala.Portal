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
    public class ProjectLinesController : ControllerBase
    {
        private readonly IProjectLineService _projectLineService;
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public ProjectLinesController(IProjectLineService projectLineService, IProjectService projectService, IMapper mapper)
        {
            _projectLineService = projectLineService;
            _projectService = projectService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all project lines or filter by project
        /// </summary>
        [HttpGet]
        [Authorize(Policy = "ProjectManagement.View")]
        public async Task<ActionResult<ApiResponse<List<ProjectLineDto>>>> GetAll([FromQuery] string? projectId)
        {
            if (string.IsNullOrEmpty(projectId))
            {
                return BadRequest(new ApiResponse<object>
                {
                    IsSuccess = false,
                    Message = "Project ID parametresi gereklidir"
                });
            }

            var linesResult = await _projectLineService.GetProjectLineListAsync(projectId);
            if (!linesResult.IsSuccess || linesResult.Data == null)
            {
                return BadRequest(new ApiResponse<object>
                {
                    IsSuccess = false,
                    Message = linesResult.Message
                });
            }

            var lineDtos = _mapper.Map<List<ProjectLineDto>>(linesResult.Data);

            return Ok(new ApiResponse<List<ProjectLineDto>>
            {
                IsSuccess = true,
                Data = lineDtos
            });
        }

        /// <summary>
        /// Get a specific project line by ID
        /// </summary>
        [HttpGet("{id}")]
        [Authorize(Policy = "ProjectManagement.View")]
        public async Task<ActionResult<ApiResponse<ProjectLineDto>>> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest(new ApiResponse<object>
                {
                    IsSuccess = false,
                    Message = "Faz ID gereklidir"
                });
            }

            var lineResult = await _projectLineService.GetProjectLineDetailAsync(id);

            if (!lineResult.IsSuccess || lineResult.Data == null)
            {
                return NotFound(new ApiResponse<object>
                {
                    IsSuccess = false,
                    Message = "Faz bulunamadı"
                });
            }

            var lineDto = _mapper.Map<ProjectLineDto>(lineResult.Data);

            return Ok(new ApiResponse<ProjectLineDto>
            {
                IsSuccess = true,
                Data = lineDto
            });
        }

        /// <summary>
        /// Create a new project line
        /// </summary>
        [HttpPost]
        [Authorize(Policy = "ProjectManagement.Create")]
        public async Task<ActionResult<ApiResponse<object>>> Create([FromBody] CreateProjectLineDto dto)
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

            var viewModel = _mapper.Map<AddProjectLineViewModel>(dto);
            viewModel.CreateTime = DateTime.Now;

            var result = await _projectLineService.AddAsync(viewModel);

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
                Message = "Faz başarıyla oluşturuldu"
            });
        }

        /// <summary>
        /// Update an existing project line
        /// </summary>
        [HttpPut("{id}")]
        [Authorize(Policy = "ProjectManagement.Update")]
        public async Task<ActionResult<ApiResponse<object>>> Update(string id, [FromBody] UpdateProjectLineDto dto)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest(new ApiResponse<object>
                {
                    IsSuccess = false,
                    Message = "Faz ID gereklidir"
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

            var viewModel = _mapper.Map<UpdateProjectLineViewModel>(dto);
            viewModel.Id = id;
            viewModel.UpdateTime = DateTime.Now;

            var result = await _projectLineService.UpdateAsync(viewModel, id);

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
                Message = "Faz başarıyla güncellendi"
            });
        }

        /// <summary>
        /// Delete a project line
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Policy = "ProjectManagement.Delete")]
        public async Task<ActionResult<ApiResponse<object>>> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest(new ApiResponse<object>
                {
                    IsSuccess = false,
                    Message = "Faz ID gereklidir"
                });
            }

            var result = await _projectLineService.DeleteAsync(id);

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
                Message = "Faz başarıyla silindi"
            });
        }

        /// <summary>
        /// Change project line status
        /// </summary>
        [HttpPost("{id}/status")]
        [Authorize(Policy = "ProjectManagement.Update")]
        public async Task<ActionResult<ApiResponse<object>>> ChangeStatus(string id, [FromBody] ChangeProjectLineStatusDto dto)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest(new ApiResponse<object>
                {
                    IsSuccess = false,
                    Message = "Faz ID gereklidir"
                });
            }

            var viewModel = new ProjectLineChangeStateStatusViewModel
            {
                Id = id,
                Status = dto.Status,
                CancelDescription = dto.CancelDescription
            };

            var result = await _projectLineService.ChangeStateStatusAsync(viewModel);

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
                Message = "Faz durumu başarıyla değiştirildi"
            });
        }

        /// <summary>
        /// Get notes for a project line
        /// </summary>
        [HttpGet("{id}/notes")]
        [Authorize(Policy = "ProjectManagement.View")]
        public async Task<ActionResult<ApiResponse<List<ProjectLineNoteDto>>>> GetNotes(string id)
        {
            var notesResult = await _projectLineService.GetProjectLineNotesAsync(id);

            if (!notesResult.IsSuccess)
            {
                return BadRequest(new ApiResponse<object>
                {
                    IsSuccess = false,
                    Message = notesResult.Message
                });
            }

            var noteDtos = _mapper.Map<List<ProjectLineNoteDto>>(notesResult.Data);

            return Ok(new ApiResponse<List<ProjectLineNoteDto>>
            {
                IsSuccess = true,
                Data = noteDtos
            });
        }
    }
}

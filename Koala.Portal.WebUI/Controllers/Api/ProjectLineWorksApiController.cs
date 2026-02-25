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
    public class ProjectLineWorksController : ControllerBase
    {
        private readonly IProjectLineWorkService _workService;
        private readonly IMapper _mapper;

        public ProjectLineWorksController(IProjectLineWorkService workService, IMapper mapper)
        {
            _workService = workService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get a specific work item by ID
        /// </summary>
        [HttpGet("{id}")]
        [Authorize(Policy = "Project.View")]
        public async Task<ActionResult<ApiResponse<ProjectLineWorkDto>>> GetById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest(new ApiResponse<object>
                {
                    IsSuccess = false,
                    Message = "İş ID gereklidir"
                });
            }

            var workResult = await _workService.GetProjectLineWorkDetailAsync(id);

            if (!workResult.IsSuccess || workResult.Data == null)
            {
                return NotFound(new ApiResponse<object>
                {
                    IsSuccess = false,
                    Message = "İş bulunamadı"
                });
            }

            var workDto = _mapper.Map<ProjectLineWorkDto>(workResult.Data);

            return Ok(new ApiResponse<ProjectLineWorkDto>
            {
                IsSuccess = true,
                Data = workDto
            });
        }

        /// <summary>
        /// Create a new work item
        /// </summary>
        [HttpPost]
        [Authorize(Policy = "Project.Create")]
        public async Task<ActionResult<ApiResponse<object>>> Create([FromBody] CreateProjectLineWorkDto dto)
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

            var viewModel = _mapper.Map<AddProjectLineWorkViewModel>(dto);

            var result = await _workService.AddAsync(viewModel);

            if (!result.IsSuccess)
            {
                return BadRequest(new ApiResponse<object>
                {
                    IsSuccess = false,
                    Message = result.Message
                });
            }

            // Return success - the service doesn't return the created ID
            return Ok(new ApiResponse<object>
            {
                IsSuccess = true,
                Message = "İş başarıyla oluşturuldu"
            });
        }

        /// <summary>
        /// Update an existing work item
        /// </summary>
        [HttpPut("{id}")]
        [Authorize(Policy = "Project.Edit")]
        public async Task<ActionResult<ApiResponse<object>>> Update(string id, [FromBody] UpdateProjectLineWorkDto dto)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest(new ApiResponse<object>
                {
                    IsSuccess = false,
                    Message = "İş ID gereklidir"
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

            var viewModel = _mapper.Map<UpdateProjectLineWorkViewModel>(dto);

            var result = await _workService.UpdateAsync(viewModel);

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
                Message = "İş başarıyla güncellendi"
            });
        }

        /// <summary>
        /// Delete a work item (Not implemented in service yet)
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Policy = "Project.Delete")]
        public async Task<ActionResult<ApiResponse<object>>> Delete(string id)
        {
            // DeleteAsync is not implemented in IProjectLineWorkService
            return Ok(new ApiResponse<object>
            {
                IsSuccess = false,
                Message = "Silme özelliği yakında aktif olacak"
            });
        }

        /// <summary>
        /// Change work item status
        /// </summary>
        [HttpPost("{id}/status")]
        [Authorize(Policy = "Project.Edit")]
        public async Task<ActionResult<ApiResponse<object>>> ChangeStatus(string id, [FromBody] ChangeProjectLineWorkStatusDto dto)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest(new ApiResponse<object>
                {
                    IsSuccess = false,
                    Message = "İş ID gereklidir"
                });
            }

            var viewModel = new ProjectLineWorkChangeStateViewModel
            {
                Id = id,
                WorkStatus = dto.Status,
                UpdateUserId = User?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? ""
            };

            var result = await _workService.ChangeWorkStateAsync(viewModel);

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
                Message = "İş durumu başarıyla değiştirildi"
            });
        }
    }
}

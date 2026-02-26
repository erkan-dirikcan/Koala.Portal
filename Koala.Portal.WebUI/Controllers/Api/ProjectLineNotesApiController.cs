using AutoMapper;
using Koala.Portal.Core.DTOs;
using Koala.Portal.Core.Services;
using Koala.Portal.Core.ViewModels.PortalViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Koala.Portal.WebUI.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjectLineNotesController : ControllerBase
    {
        private readonly IProjectLineService _projectLineService;
        private readonly IMapper _mapper;

        public ProjectLineNotesController(IProjectLineService projectLineService, IMapper mapper)
        {
            _projectLineService = projectLineService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get notes for a specific project line
        /// </summary>
        [HttpGet("byLine/{projectLineId}")]
        // [Authorize(Policy = "ProjectManagement.View")]
        public async Task<ActionResult<ApiResponse<List<ProjectLineNoteDto>>>> GetByProjectLine(string projectLineId)
        {
            if (string.IsNullOrEmpty(projectLineId))
            {
                return BadRequest(new ApiResponse<object>
                {
                    IsSuccess = false,
                    Message = "Proje Faz ID gereklidir"
                });
            }

            var notesResult = await _projectLineService.GetProjectLineNotesAsync(projectLineId);

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

        /// <summary>
        /// Get a specific note by ID
        /// </summary>
        [HttpGet("{id}")]
        // [Authorize(Policy = "ProjectManagement.View")]
        public async Task<ActionResult<ApiResponse<ProjectLineNoteDto>>> GetById(string id)
        {
            // Note detail retrieval not directly implemented
            return NotFound(new ApiResponse<object>
            {
                IsSuccess = false,
                Message = "Not detay getirme özelliği yakında eklenecektir"
            });
        }

        /// <summary>
        /// Create a new note
        /// </summary>
        [HttpPost]
        // [Authorize(Policy = "ProjectManagement.Create")]
        public async Task<ActionResult<ApiResponse<object>>> Create([FromBody] CreateProjectLineNoteDto dto)
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

            var viewModel = _mapper.Map<AddProjectLineNoteViewModel>(dto);
            viewModel.CreateTime = DateTime.Now;

            var result = await _projectLineService.AddProjectLineNote(viewModel);

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
                Message = "Not başarıyla oluşturuldu"
            });
        }

        /// <summary>
        /// Update an existing note
        /// </summary>
        [HttpPut("{id}")]
        // [Authorize(Policy = "ProjectManagement.Update")]
        public async Task<ActionResult<ApiResponse<object>>> Update(string id, [FromBody] UpdateProjectLineNoteDto dto)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest(new ApiResponse<object>
                {
                    IsSuccess = false,
                    Message = "Not ID gereklidir"
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

            var viewModel = new UpdateProjectLineNoteViewModel
            {
                Id = id,
                ReportNote = dto.Content,
                UpdateTime = DateTime.Now
            };

            var result = await _projectLineService.UpdateProjectLineNote(viewModel);

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
                Message = "Not başarıyla güncellendi"
            });
        }

        /// <summary>
        /// Delete a note
        /// </summary>
        [HttpDelete("{id}")]
        // [Authorize(Policy = "ProjectManagement.Delete")]
        public async Task<ActionResult<ApiResponse<object>>> Delete(string id)
        {
            // DeleteProjectLineNote is not implemented in IProjectLineService
            return Ok(new ApiResponse<object>
            {
                IsSuccess = false,
                Message = "Silme özelliği yakında aktif olacak"
            });
        }
    }
}

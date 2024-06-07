using Microsoft.AspNetCore.Mvc;
using Unicam.Cloud.Exam.Menu.Application.Abstractions.Services;
using Unicam.Cloud.Exam.Menu.Application.Factories;
using Unicam.Cloud.Exam.Menu.Application.Models.DTOs;
using Unicam.Cloud.Exam.Menu.Application.Models.Requests;
using Unicam.Cloud.Exam.Menu.Application.Models.Responses;
using Unicam.Cloud.Exam.Menu.Models.Entities;

namespace Unicam.Cloud.Exam.Menu.Web.Controllers {
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DishTypeController : ControllerBase {
        public readonly IDishTypeService _dishTypeService;

        public DishTypeController(IDishTypeService dishTypeService) {
            _dishTypeService = dishTypeService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAllAsync() {
            try {
                var dishTypesDTOs = new List<DishTypeDTO>();
                foreach (var dishType in await _dishTypeService.GetAllAsync()) {
                    dishTypesDTOs.Add(new DishTypeDTO(dishType));
                }
                var dishTypesResponse = new EntitiesResponse<DishTypeDTO> {
                    Entities = dishTypesDTOs
                };
                return Ok(ResponseFactory.WithSuccess(dishTypesResponse));
            }catch(Exception e){
                return BadRequest(ResponseFactory.WithError(e));
            }
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id) {
            try {
                var dishType = await _dishTypeService.GetByIdAsync(id);
                var dishResponse = new EntityResponse<DishTypeDTO> {
                    Result = new DishTypeDTO(dishType)
                };
                return Ok(ResponseFactory.WithSuccess(dishResponse));
            }catch(Exception e){
                return BadRequest(ResponseFactory.WithError(e));
            }
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromBody] DishTypeAddRequest dishTypeAddRequest) {
            try {
                await _dishTypeService.AddAsync(dishTypeAddRequest.ToEntity());
                return Ok(ResponseFactory.WithSuccess("Dish Type Added"));
            }catch(Exception e){
                return BadRequest(ResponseFactory.WithError(e));
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id) {
            try {
                await _dishTypeService.DeleteAsync(id);
                return Ok(ResponseFactory.WithSuccess("Dish Type deleted"));
            }catch(Exception e){
                return BadRequest(ResponseFactory.WithError(e));
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] DishTypeUpdateRequest dishTypeUpdateRequest) {
            try {
                await _dishTypeService.UpdateAsync(dishTypeUpdateRequest.DishTypeId, dishTypeUpdateRequest.DishType.ToEntity());
                return Ok(ResponseFactory.WithSuccess("Dish Type updated"));
            }catch(Exception e){
                return BadRequest(ResponseFactory.WithError(e));
            }
        }

    }
}

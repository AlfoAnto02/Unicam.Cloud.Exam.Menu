using Microsoft.AspNetCore.Mvc;
using Unicam.Cloud.Exam.Menu.Application.Abstractions.Services;
using Unicam.Cloud.Exam.Menu.Application.Factories;
using Unicam.Cloud.Exam.Menu.Application.Models.DTOs;
using Unicam.Cloud.Exam.Menu.Application.Models.Requests;
using Unicam.Cloud.Exam.Menu.Application.Models.Responses;

namespace Unicam.Cloud.Exam.Menu.Web.Controllers {
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DishController : ControllerBase {
        public readonly IDishService _dishService;
        public readonly IDishTypeService _dishTypeService;

        public DishController(IDishService dishService, IDishTypeService dishTypeService) {
            _dishService = dishService;
            _dishTypeService = dishTypeService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAllAsync() {
            try {
                var dishesDTOs = new List<DishDTO>();
                foreach (var dish in await _dishService.GetAllAsync()) {
                    dishesDTOs.Add(new DishDTO(dish));
                }
                var dishesResponse = new EntitiesResponse<DishDTO> {
                    Entities = dishesDTOs
                };
                return Ok(ResponseFactory.WithSuccess(dishesResponse));
            }catch(Exception e) {
                return BadRequest(ResponseFactory.WithError(e));
            }
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id) {
            try {
                var dish = await _dishService.GetByIdAsync(id);
                var dishResponse = new EntityResponse<DishDTO> {
                    Result = new DishDTO(dish)
                };
                return Ok(ResponseFactory.WithSuccess(dishResponse));
            }catch(Exception e) {
                return BadRequest(ResponseFactory.WithError(e));
            }
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromBody] DishAddRequest dishAddRequest) {
            try {
                var dish = dishAddRequest.ToEntity();
                await _dishService.AddAsync(dish);
                await _dishTypeService.AddDishToTipologyAsync(dishAddRequest.TypeID, dish.Id);
                return Ok(ResponseFactory.WithSuccess("Dish added"));
            }catch(Exception e) {
                return BadRequest(ResponseFactory.WithError(e));
            }
                
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] DishUpdateRequest dishUpdateRequest) {
            try {
                await _dishService.UpdateAsync(dishUpdateRequest.DishId, dishUpdateRequest.Dish.ToEntity());
                await _dishTypeService.AddDishToTipologyAsync(dishUpdateRequest.Dish.TypeID, dishUpdateRequest.DishId);
                return Ok(ResponseFactory.WithSuccess("Dish updated"));
            }catch(Exception e) {
                return BadRequest(ResponseFactory.WithError(e));
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAsync(int id) {
            try {
                await _dishService.DeleteAsync(id);
                return Ok(ResponseFactory.WithSuccess("Dish deleted"));
            }catch(Exception e) {
                return BadRequest(ResponseFactory.WithError(e));
            }
        }

        [HttpGet("getByType/{typeId}")]
        public async Task<IActionResult> GetByTypeAsync(int typeId) {
            try {
                var dishesDTOs = new List<DishDTO>();
                foreach (var dish in await _dishService.GetByTypologyIdAsync(typeId)) {
                    dishesDTOs.Add(new DishDTO(dish));
                }
                var dishesResponse = new EntitiesResponse<DishDTO> {
                    Entities = dishesDTOs
                };
                return Ok(ResponseFactory.WithSuccess(dishesResponse));
            }catch(Exception e) {
                return BadRequest(ResponseFactory.WithError(e));
            }
        }

        [HttpPost("getWithPriceGreatherThan")]
        public async Task<IActionResult> GetWithPriceGreatherThanAsync([FromBody] PriceRequest priceRequest) {
            try {
                var dishesDTOs = new List<DishDTO>();
                foreach (var dish in await _dishService.GetWithPriceGreatherThanAsync(priceRequest.Price)) {
                    dishesDTOs.Add(new DishDTO(dish));
                }
                var dishesResponse = new EntitiesResponse<DishDTO> {
                    Entities = dishesDTOs
                };
                return Ok(ResponseFactory.WithSuccess(dishesResponse));
            }catch(Exception e) {
                return BadRequest(ResponseFactory.WithError(e));
            }
        }

        [HttpPost("getWithPriceLessThan")]
        public async Task<IActionResult> GetWithPriceLessThanAsync([FromBody] PriceRequest priceRequest) {
            try {
                var dishesDTOs = new List<DishDTO>();
                foreach (var dish in await _dishService.GetWithPriceLessThanAsync(priceRequest.Price)) {
                    dishesDTOs.Add(new DishDTO(dish));
                }
                var dishesResponse = new EntitiesResponse<DishDTO> {
                    Entities = dishesDTOs
                };
                return Ok(ResponseFactory.WithSuccess(dishesResponse));
            }catch(Exception e) {
                return BadRequest(ResponseFactory.WithError(e));
            }
        }

        [HttpPost("getByTypology")]
        public async Task<IActionResult> GetByTypologyAsync([FromBody] TypologyRequest typologyRequest) {
            try {
                var dishesDTOs = new List<DishDTO>();
                foreach (var dish in await _dishService.GetByTypologyAsync(typologyRequest.Typology)) {
                    dishesDTOs.Add(new DishDTO(dish));
                }
                var dishesResponse = new EntitiesResponse<DishDTO> {
                    Entities = dishesDTOs
                };
                return Ok(ResponseFactory.WithSuccess(dishesResponse));
            }catch(Exception e) {
                return BadRequest(ResponseFactory.WithError(e));
            }
        }
    }
}

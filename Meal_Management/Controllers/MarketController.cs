using Meal_Management.Data;
using Meal_Management.Models;
using Meal_Management.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Meal_Management.Controllers
{
    [Route("api/market")]
    [ApiController]
    public class MarketController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponceDto _responceDto;
        public MarketController(AppDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _responceDto = new ResponceDto();
        }

        [HttpGet]
        public ResponceDto Get()
        {
            try
            {
              IEnumerable<Market> marketList=_db.markets.ToList();
                double totalMeal = marketList.Sum(x => x.totalDailyMeal);
                double totalMarket = marketList.Sum(x => x.totalDailyMarket);
                var marketDtoList = new List<marketDto>();
                foreach (var item in marketList)
                {
                    marketDto totalMarketList = new marketDto()
                    {
                        marketId=item.marketId, 
                        marketDate = item.marketDate,
                        totalDailyMarket=item.totalDailyMarket,
                        totalDailyMeal=item.totalDailyMeal,
                        totalMarket = totalMarket,
                        totalMeal=totalMeal,
                        totalMealRate=Math.Round(totalMarket / totalMeal),
                        DailyMealRate = Math.Round((item.totalDailyMarket / item.totalDailyMeal)),
                    };
                    marketDtoList.Add(totalMarketList);
                }
                _responceDto.Result = marketDtoList;
                _responceDto.Massage = "successfull";
            }catch (Exception ex)
            {
                _responceDto.Massage=ex.Message;
                _responceDto.isSuccess=false;
            }
            return _responceDto;
        }

        [HttpPost]
        public ResponceDto Post([FromBody] marketDto market)
        {
            try
            {
                Market marketList = new Market()
                {
                    marketDate = market.marketDate,
                    totalDailyMarket = market.totalDailyMarket,
                    totalDailyMeal=market.totalDailyMeal,
                };
                _db.markets.Add(marketList);
                _db.SaveChanges();
                _responceDto.Result = marketList;
            }
            catch (Exception ex)
            {
                _responceDto.Massage = ex.Message;
                _responceDto.isSuccess = false;
            }
            return _responceDto;
        }

        [HttpPut]
        public object Put([FromBody] marketDto market)
        {
            try
            {
                Market marketList = new Market()
                {
                    marketId=market.marketId,
                    marketDate = market.marketDate,
                    totalDailyMarket = market.totalDailyMarket,
                    totalDailyMeal = market.totalDailyMeal,
                };
                _db.markets.Update(marketList);
                _db.SaveChanges();
                _responceDto.Result = marketList;
            }
            catch (Exception ex)
            {
                _responceDto.Massage = ex.Message;
                _responceDto.isSuccess = false;
            }
            return _responceDto;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public object Delete(int id)
        {
            try
            {
                Market markets = _db.markets.First(x => x.marketId == id);
                _db.markets.Remove(markets);
                _db.SaveChanges();
                _responceDto.Massage="successfull";
            }
            catch(Exception ex)
            {
                _responceDto.Massage = ex.Message;
                _responceDto.isSuccess = false;
            }
            return _responceDto;
        }
    }
}

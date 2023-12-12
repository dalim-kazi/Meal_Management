using Meal_Management.Data;
using Meal_Management.Models;
using Meal_Management.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Meal_Management.Controllers
{
    [Route("api/meal_manage")]
    [ApiController]
    public class MealManageController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponceDto _responceDto;
        public MealManageController(AppDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _responceDto= new ResponceDto();
        }
        [HttpGet]
        public ResponceDto Get()
        {
            try
            {
              IEnumerable<MealManagement>mealManagementsList =_db.mealManagements.ToList();
                IEnumerable<Market> marketList = _db.markets.ToList();
                double totalMeal = marketList.Sum(x => x.totalDailyMeal);
                double totalMarket = marketList.Sum(x => x.totalDailyMarket);
                 var mealRate =totalMarket / totalMeal;
                var mealList =new List<mealDto>();
                foreach (var item in mealManagementsList)
                {
                   mealDto meals =new mealDto()
                    {
                       userId=item.userId,
                       dateTime=item.mealDate,  
                       userName=item.userName,
                       email=item.email,
                       meal=item.meal,
                       totalCost=Math.Round(mealRate * item.meal),
                       deposit=item.deposit,
                       due =item.deposit < (item.meal * mealRate)? Math.Round(((item.meal * mealRate) - item.deposit)) :0,
                       refund = item.deposit > (item.meal * mealRate) ? Math.Round((item.deposit - (item.meal * mealRate))) :0,
                       mealRate=Math.Round(mealRate)
                    };
                    mealList.Add(meals);

                     
                }
                _responceDto.Result=mealList;
                _responceDto.Massage = "successfull";
            }catch (Exception ex)
            {
                _responceDto.Massage=ex.Message;
                _responceDto.isSuccess=false;
            }
            return _responceDto;
        }
        [HttpGet]
        [Route("{email}")]
        public ResponceDto GetByEmailAll([FromQuery] string email)
        {
            try
            {
                IEnumerable<MealManagement> mealManagement =_db.mealManagements.Where(x=>x.email == email).ToList();
                IEnumerable<Market> marketList = _db.markets.ToList();
                double totalMeal = marketList.Sum(x => x.totalDailyMeal);
                double totalMarket = marketList.Sum(x => x.totalDailyMarket);
                var mealRate = totalMarket / totalMeal;
                double totalDeposit = mealManagement.Sum(x => x.deposit);
                int userTotalMeal =mealManagement.Sum(x=>x.meal);
                var UserTotalCost = Math.Round(userTotalMeal * mealRate);
                var userDue = totalDeposit < UserTotalCost ? Math.Round(UserTotalCost - totalDeposit) : 0;
                var userRefund = totalDeposit > UserTotalCost ? Math.Round(totalDeposit - UserTotalCost) : 0;
                var mealList = new List<mealDto>();
                foreach (var item in mealManagement)
                {
                    mealDto meals = new mealDto()
                    {
                        userId = item.userId,
                        userName = item.userName,
                        email = item.email,
                        dateTime = item.mealDate,
                        deposit =item.deposit,
                        meal = item.meal,
                        totalMeal= userTotalMeal,
                        mealRate =mealRate,
                        totalCost =UserTotalCost,
                        due = userDue,
                        refund = userRefund,
                        totalDeposit=totalDeposit
                    };
                    mealList.Add(meals);
                }
                _responceDto.Result = mealList;

            }
            catch(Exception ex)
            {
                _responceDto.Massage = ex.Message;
                _responceDto.isSuccess = false;
            }
            return _responceDto;
        }

        [HttpPost]
        public ResponceDto Post([FromBody] mealDto meals)
        {
            try
            {
                MealManagement  mealList =new MealManagement()
                {
                  mealDate =meals.dateTime,
                   userName =meals.userName,
                   email =meals.email,
                   meal =meals.meal,
                   deposit =meals.deposit,
                };
                _db.mealManagements.Add(mealList);
                _db.SaveChanges();
                _responceDto.Result =mealList;
            }
            catch (Exception ex)
            {
                _responceDto.Massage = ex.Message;
                _responceDto.isSuccess = false;
            }
            return _responceDto;
        }
        [HttpPut]
        public object Put([FromBody] mealDto meals)
        {
            try
            {
               MealManagement mealManagement =new MealManagement()
                {
                    userId =meals.userId,
                    mealDate=meals.dateTime,
                    userName=meals.userName,
                    email=meals.email,
                    meal =meals.meal,
                    deposit =meals.deposit,
                };
                _db.mealManagements.Update(mealManagement);
                _db.SaveChanges();
                _responceDto.Result = mealManagement;
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
                MealManagement mealManagement = _db.mealManagements.First(x => x.userId == id);
                _db.mealManagements.Remove(mealManagement);
                _db.SaveChanges();
                _responceDto.Massage = "successfull";
            }
            catch (Exception ex)
            {
                _responceDto.Massage = ex.Message;
                _responceDto.isSuccess = false;
            }
            return _responceDto;
        }
    }
}

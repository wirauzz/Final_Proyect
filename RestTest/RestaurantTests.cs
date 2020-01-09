using AutoMapper;
using Moq;
using Restaurante_Proyecto.Data;
using Restaurante_Proyecto.Data.Entities;
using Restaurante_Proyecto.Data.Repository;
using Restaurante_Proyecto.Exceptions;
using Restaurante_Proyecto.Models;
using Restaurante_Proyecto.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace RestTest
{
    public class RestaurantTests
    {
        private Mapper mapper;
        private Mock<IFoodMapRepository> MoqFoodRepository;
        public RestaurantTests()
        {
            //Moq Arangement
            this.MoqFoodRepository = new Mock<IFoodMapRepository>();
            
            //Mapper configuration
            var myProfile = new Restaurante_ProyectoProfile();
            var configuration = new MapperConfiguration(config => config.AddProfile(myProfile));
            this.mapper = new Mapper(configuration);
        }
        [Fact]
        public async void RestaurantService_ShouldReturnExceptionIfNotValid()
        {
            //Arrange things
            int restaurantId = 1024;
            var restaurantEntity = new RestaurantEntity() { Id = 15, Name = "Las Moras", 
                                                            FoodStyle = "Churrasquería", 
                                                            AddressNumber = 234, 
                                                            Street = "Somewhere St." };
            MoqFoodRepository.Setup(m => m.GetRestaurantAsync(restaurantId)).Returns(Task.FromResult(restaurantEntity));

            //Service Called
            var restaurantService = new RestaurantService(MoqFoodRepository.Object, mapper);
            
            //Act - Execute
            await Assert.ThrowsAsync<NotFoundItemException>(() => restaurantService.GetRestaurantAsync(15));
        }
        [Fact]
        public async void RestaurantService_ShouldReturnNotNullIfCreated()
        {
            //Arrange things
            var restaurantEntity = new RestaurantEntity()
            {
                Name = "Las Moras",
                FoodStyle = "Churrasquería",
                AddressNumber = 234,
                Street = "Somewhere St."
            };
            //Starting conditions requested for the test
            MoqFoodRepository.Setup(m => m.SaveChangesAsync()).Returns(Task.FromResult(true));

            //Arrange things to send
            var restaurantModel = mapper.Map<Restaurant>(restaurantEntity);
            var restaurantService = new RestaurantService(MoqFoodRepository.Object, mapper);

            //Act - Execute
            Assert.NotNull(await restaurantService.CreateRestaurantAsync(restaurantModel));
        }
        [Fact]
        public async void RestaurantService_ShouldReturnChangesNotExecutedExceptionIfEnteringToTheDataBaseNotAllowed()
        {
            //Arrange things
            var restaurantEntity = new RestaurantEntity()
            {
                Name = "Las Moras",
                FoodStyle = "Churrasquería",
                AddressNumber = 234,
                Street = "Somewhere St."
            };
            //Starting conditions requested for the test
            MoqFoodRepository.Setup(m => m.SaveChangesAsync()).Returns(Task.FromResult(false));

            //Arrange things to send
            var restaurantModel = mapper.Map<Restaurant>(restaurantEntity);
            var restaurantService = new RestaurantService(MoqFoodRepository.Object, mapper);

            //Act - Execute
            await Assert.ThrowsAsync<ChangesNotExecutedException>(() => restaurantService.CreateRestaurantAsync(restaurantModel));
        }
        [Fact]
        public async void RestaurantService_ShouldReturnWrongOperationIfNotAllowedConditions()
        {
            //Arrange things
            var restaurantURLId = 34;
            var restaurantEntity = new RestaurantEntity()
            {
                Id = 15,
                Name = "Las Moras",
                FoodStyle = "Churrasquería",
                AddressNumber = 234,
                Street = "Somewhere St."
            };
            var restaurantEntityURL = new RestaurantEntity()
            {
                Id = 34,
                Name = "El Rodizio",
                FoodStyle = "Churrasquería",
                AddressNumber = 234,
                Street = "Somewhere St."
            };
            MoqFoodRepository.Setup(m => m.GetRestaurantAsync(restaurantURLId)).Returns(Task.FromResult(restaurantEntityURL));

            //Arrange things to send
            var restaurantModel = mapper.Map<Restaurant>(restaurantEntity);
            var restaurantService = new RestaurantService(MoqFoodRepository.Object, mapper);

            //Execute
            await Assert.ThrowsAsync<WrongOperationException>(() => restaurantService.UpdateRestaurantAsync(restaurantURLId,restaurantModel));
        }

    }
}

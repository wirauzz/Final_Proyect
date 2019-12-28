import { Component, OnInit } from '@angular/core';
import { Restaurant } from 'src/app/models/restaurant';
import { RestaurantService } from 'src/app/services/restaurant.service';

@Component({
  selector: 'app-restaurants',
  templateUrl: './restaurants.component.html',
  styleUrls: ['./restaurants.component.css']
})
export class RestaurantsComponent implements OnInit {
  restaurants:Restaurant[];

  constructor(private restaurantService:RestaurantService) { }

  ngOnInit() {
    this.restaurantService.getRestaurants().subscribe(restaurants => {
      this.restaurants = restaurants;
    });
  }

  deleteRestaurant(restaurant:Restaurant) {
    this.restaurants = this.restaurants.filter(r => r.id != restaurant.id);
    this.restaurantService.deleteRestaurant(restaurant).subscribe();
  }

  addRestaurant(restaurant:Restaurant) { 
    this.restaurantService.addRestaurant(restaurant).subscribe(restaurant => {
      this.restaurants.push(restaurant);
    });
  }

  editRestaurant(restaurant:Restaurant)
  {
    this.restaurantService.putRestaurant(restaurant).subscribe();
  }

  getDishes(restaurant:Restaurant)
  {
    
  }

}

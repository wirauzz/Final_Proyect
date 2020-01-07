import { Component, OnInit } from '@angular/core';
import { Restaurant } from 'src/app/models/restaurant';
import { ActivatedRoute } from "@angular/router";
import { RestaurantService } from 'src/app/services/restaurant.service';

@Component({
  selector: 'app-body-dishes',
  templateUrl: './body-dishes.component.html',
  styleUrls: ['./body-dishes.component.css']
})
export class BodyDishesComponent implements OnInit {
  restaurant:Restaurant;
  constructor(private route: ActivatedRoute, private restaurantService:RestaurantService) { }

  ngOnInit() {   
    this.route.params.subscribe( params => this.restaurantService.getRestaurant(params['id']).subscribe(restaurant => {
      this.restaurant = restaurant
      })); 
  }

}

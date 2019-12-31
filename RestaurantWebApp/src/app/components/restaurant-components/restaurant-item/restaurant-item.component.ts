import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Restaurant } from 'src/app/models/restaurant';
import { RestaurantService } from 'src/app/services/restaurant.service';


@Component({
  selector: 'app-restaurant-item',
  templateUrl: './restaurant-item.component.html',
  styleUrls: ['./restaurant-item.component.css']
})
export class RestaurantItemComponent implements OnInit {
  @Input() restaurant:Restaurant;
  @Output() deleteRestaurant:EventEmitter<Restaurant> = new EventEmitter();
  @Output() getDishesFromRestaurant:EventEmitter<Restaurant> = new EventEmitter();

  constructor(private restaurantService:RestaurantService) { }

  ngOnInit() {
  }

  onDelete(restaurant) {
    this.deleteRestaurant.emit(restaurant);
  }

  onRedirect(restaurant) { 
    this.getDishesFromRestaurant.emit(restaurant);
  }


}

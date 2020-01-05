import { Component, OnInit } from '@angular/core';
import { Restaurant } from 'src/app/models/restaurant';
import { RestaurantService } from 'src/app/services/restaurant.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  restaurants:Restaurant[];
  
  constructor(private restaurantService:RestaurantService) { }

  ngOnInit() {
    localStorage.removeItem("restaurant");
  }


}

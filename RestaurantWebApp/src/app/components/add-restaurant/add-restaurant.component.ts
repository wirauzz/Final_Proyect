import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { Restaurant } from 'src/app/models/restaurant';

@Component({
  selector: 'app-add-restaurant',
  templateUrl: './add-restaurant.component.html',
  styleUrls: ['./add-restaurant.component.css']
})
export class AddRestaurantComponent implements OnInit {
  @Output() addRestaurant: EventEmitter<any> = new EventEmitter();
  name:string;
  foodStyle:string;
  street:string;
  addressNumber:number;
  constructor() { }

  ngOnInit() {
  }
  
  onSubmit() {
    const restaurant = {
      name: this.name,
      foodStyle: this.foodStyle,
      street: this.street,
      addressNumber: this.addressNumber,
      completed:false
    }
    this.addRestaurant.emit(restaurant);
  }

}

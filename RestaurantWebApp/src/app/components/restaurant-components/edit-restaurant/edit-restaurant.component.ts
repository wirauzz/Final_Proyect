import { Component, OnInit, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-edit-restaurant',
  templateUrl: './edit-restaurant.component.html',
  styleUrls: ['./edit-restaurant.component.css']
})
export class EditRestaurantComponent implements OnInit {
  @Output() editRestaurant: EventEmitter<any> = new EventEmitter();
  id:number;
  name:string;
  foodStyle:string;
  street:string;
  addressNumber:number;
  imagePath:string;
  constructor() { }

  ngOnInit() {
  }

  onEdit() {
    const restaurant = {
      id:this.id,
      name: this.name,
      foodStyle: this.foodStyle,
      street: this.street,
      addressNumber: this.addressNumber,
      imagePath:this.imagePath
    }
    this.editRestaurant.emit(restaurant);
  }


}

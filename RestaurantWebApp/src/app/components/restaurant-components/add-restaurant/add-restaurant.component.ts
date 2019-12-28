import { Component, OnInit, EventEmitter, Output } from '@angular/core';

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
  filePath:File;
  constructor() { }

  ngOnInit() {
  }
  
  onSubmit() {
    const restaurant = {
      name: this.name,
      foodStyle: this.foodStyle,
      street: this.street,
      addressNumber: this.addressNumber,
      filePath:this.filePath
    }
    this.addRestaurant.emit(restaurant);
  }

}

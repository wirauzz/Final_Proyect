import { Component, OnInit, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-add-dish',
  templateUrl: './add-dish.component.html',
  styleUrls: ['./add-dish.component.css']
})
export class AddDishComponent implements OnInit {
  @Output() addDish: EventEmitter<any> = new EventEmitter();
  name:string;
  mainIngredient:string;
  nationality:string;
  cost:number;
  size:string;
  restaurantId:number;
  imagePath:String;
  constructor() { }

  ngOnInit() {
  }

  
  onSubmit() {
    const dish = {
      name: this.name,
      mainIngredient: this.mainIngredient,
      nationality: this.nationality,
      cost: this.cost,
      size:this.size,
      restaurantId:this.restaurantId,
      imagePath:this.imagePath
    }
    this.addDish.emit(dish);
  }

}

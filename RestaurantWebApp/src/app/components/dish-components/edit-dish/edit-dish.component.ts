import { Component, OnInit, EventEmitter, Output } from '@angular/core';
@Component({
  selector: 'app-edit-dish',
  templateUrl: './edit-dish.component.html',
  styleUrls: ['./edit-dish.component.css']
})
export class EditDishComponent implements OnInit {
  @Output() editDish: EventEmitter<any> = new EventEmitter();
  id:number;
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

  
  onEdit() {
    const dish = {
      id: this.id,
      name: this.name,
      mainIngredient: this.mainIngredient,
      nationality: this.nationality,
      cost: this.cost,
      size:this.size,
      restaurantId:this.restaurantId,
      imagePath:this.imagePath
    }
    this.editDish.emit(dish);
  }
}

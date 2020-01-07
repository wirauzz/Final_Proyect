import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { ActivatedRoute } from "@angular/router";
import { DishService } from 'src/app/services/dish.service';
import { Dish } from 'src/app/models/dish';

@Component({
  selector: 'app-edit-dish',
  templateUrl: './edit-dish.component.html',
  styleUrls: ['./edit-dish.component.css']
})
export class EditDishComponent implements OnInit {
  @Output() editDish: EventEmitter<any> = new EventEmitter();
  dish:Dish;
  id:number;
  name:string;
  mainIngredient:string;
  nationality:string;
  cost:number;
  size:string;
  restaurantId:number;
  imagePath:String;
  constructor(private dishService:DishService, private route:ActivatedRoute) { }

  ngOnInit() {
    this.route.params.subscribe( params => this.dishService.getDish(params['id'],params['idDish']).subscribe(dish => {
      this.dish = dish
    }));
    console.log(this.dish);
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

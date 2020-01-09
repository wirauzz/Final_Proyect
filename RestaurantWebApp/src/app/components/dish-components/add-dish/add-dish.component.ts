import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { ActivatedRoute, Router } from "@angular/router";

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
  imagePath:String;
  constructor( private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
  }

  
  onSubmit() {
    const dish = {
      name: this.name,
      mainIngredient: this.mainIngredient,
      nationality: this.nationality,
      cost: this.cost,
      size:this.size,
      restaurantId:this.activatedRoute.snapshot.params['id'],
      imagePath:this.imagePath
    }
    this.addDish.emit(dish);
  }

}

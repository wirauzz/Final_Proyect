import { Dish } from 'src/app/models/dish';

export class Restaurant {
    id:number;
    name:string;
    foodStyle:string;
    street:string;
    addressNumber:number;
    dishes:Array<Dish>;
    imagePath:String;
    
}
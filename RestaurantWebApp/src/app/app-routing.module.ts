import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DishesPageComponent } from './components/pages/dishes-page/dishes-page.component';
import { HomePageComponent } from './components/pages/home-page/home-page.component';
import { EditDishComponent } from './components/dish-components/edit-dish/edit-dish.component';
import { EditRestaurantComponent } from './components/restaurant-components/edit-restaurant/edit-restaurant.component';
import { AddRestaurantComponent } from './components/restaurant-components/add-restaurant/add-restaurant.component';
import { AddDishComponent } from './components/dish-components/add-dish/add-dish.component';


const routes: Routes = [
  { path: 'restaurants/:id/dishes', component: DishesPageComponent },
  { path: 'restaurants/:id/dishes/edit/:idDish', component: EditDishComponent},
  { path: 'restaurants/edit/:id', component: EditRestaurantComponent},
  { path: 'restaurants', component: HomePageComponent},
  { path: '', component: HomePageComponent},
  { path: 'restaurants/add', component: AddRestaurantComponent},
  { path: 'restaurants/:id/dishes/add', component: AddDishComponent}
  
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

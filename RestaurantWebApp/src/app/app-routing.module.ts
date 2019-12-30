import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DishesPageComponent } from './components/pages/dishes-page/dishes-page.component';
import { RestaurantsPageComponent } from './components/pages/restaurants-page/restaurants-page.component';


const routes: Routes = [
  { path: 'dishes', component: DishesPageComponent },
  { path: '', component: RestaurantsPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

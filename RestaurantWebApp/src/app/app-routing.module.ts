import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DishesPageComponent } from './components/pages/dishes-page/dishes-page.component';
import { RestaurantsPageComponent } from './components/pages/restaurants-page/restaurants-page.component';
import { HomePageComponent } from './components/pages/home-page/home-page.component';


const routes: Routes = [
  { path: 'dishes', component: DishesPageComponent },
  { path: 'restaurants', component: RestaurantsPageComponent},
  { path: '', component: HomePageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

import { AuthGuard } from './auth/auth.guard';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { LoginComponent } from './user/login/login.component';
import { HomeComponent } from './home/home.component';
import { ProductComponent } from './product/product.component';
import { CartComponent } from './cart/cart.component';
import { OrderComponent } from './order/order.component';
import { OrderHistoryComponent } from './order-history/order-history.component';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';

const routes: Routes = [
  {path:'',redirectTo:'/user/login',pathMatch:'full'},
  {
    path: 'user', component: UserComponent,
    children: [
      { path: 'registration', component: RegistrationComponent },
      { path: 'login', component: LoginComponent }
    ]
  },
  { path: 'cart', component: CartComponent ,canActivate:[AuthGuard]},
  {path:'home',component:HomeComponent,canActivate:[AuthGuard]},
  {path:'product',component: ProductComponent,canActivate:[AuthGuard]},
  {path:'adminpanel',component: AdminPanelComponent,canActivate:[AuthGuard], data: {permittedRoles: ['Admin']}},
  {path:'forbidden',component: ForbiddenComponent,canActivate:[AuthGuard]},
  {path:'orderhistory',component: OrderHistoryComponent,canActivate:[AuthGuard]},
  {path:'order',component: OrderComponent,canActivate:[AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

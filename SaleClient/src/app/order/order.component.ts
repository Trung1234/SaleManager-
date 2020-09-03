import { Component, OnInit } from '@angular/core';
import { Cart } from '../models/cart';
import { ToastrService } from 'ngx-toastr';
import { UserService } from '../shared/user.service';
import { Order } from '../models/order';
import { OrderService } from '../shared/order.service';
import { OrderDetail } from '../models/orderdetail';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {
  public userDetails;
  public items: Cart[] = [];
  public orderDetails: OrderDetail[] = [];
	public total: number = 0;
  public orders$: Observable<Order[]>;

	constructor(
    private router: Router,
     private service: UserService,
     private orderService: OrderService,
     private toastr: ToastrService
	) { }

	ngOnInit() {
    this.service.getUserProfile().subscribe(
      res => {
        this.userDetails = res;
      },
      err => {
        console.log(err);
      },
    );

		this.loadCart();
	}
  loadOrders() {
    this.orders$ = this.orderService.getOrders();
  }
	loadCart(): void {
		this.total = 0;
		this.items = [];
		let cart = JSON.parse(localStorage.getItem('cart'));
		for (var i = 0; i < cart.length; i++) {
			let item = JSON.parse(cart[i]);
			this.items.push({
				product: item.product,
				quantity: item.quantity
      });
      this.orderDetails.push({
				product: item.product,
				quantity: item.quantity
			});
			this.total += item.product.price * item.quantity;
		}
  }

	remove(id: number): void {
		let cart: any = JSON.parse(localStorage.getItem('cart'));
		let index: number = -1;
		for (var i = 0; i < cart.length; i++) {
			let item: Cart = JSON.parse(cart[i]);
			if (item.product.id == id) {
				cart.splice(i, 1);
				break;
			}
		}
		localStorage.setItem("cart", JSON.stringify(cart));
		this.loadCart();
  }

  checkOut(): void{
      let order: Order = {
        shipName : this.userDetails.userName,
        shipEmail : this.userDetails.email,
        shipAddress: "",
        shipPhoneNumber: "",
        orderDetails: this.orderDetails,
        totalPrice: this.total
    };
    this.orderService.saveOrder(order)
      .subscribe((data) => {
        localStorage.removeItem('cart');
        this.router.navigate(['/product']);
        this.toastr.success("Create order succesfully");
      });
  }
}


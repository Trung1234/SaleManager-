import { Component, OnInit } from '@angular/core';
import { OrderService } from '../shared/order.service';
import { Observable } from 'rxjs';
import { Order } from '../models/order';

@Component({
  selector: 'app-order-history',
  templateUrl: './order-history.component.html',
  styleUrls: ['./order-history.component.css']
})
export class OrderHistoryComponent implements OnInit {

  public orders: Observable<Order[]>;

	constructor(
     private orderService: OrderService
	) { }

	ngOnInit() {
		this.loadOrders();
  }

  loadOrders() {
    this.orders = this.orderService.getOrders();
  }
}

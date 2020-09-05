import { OrderDetail } from './orderdetail';

export class Order {
  iD: number;
  orderDate: Date;
  shipName: string;
  shipAddress: string;
  shipEmail: string;
  shipPhoneNumber: string;
  totalPrice: number;
  orderDetails : OrderDetail[] ;
}

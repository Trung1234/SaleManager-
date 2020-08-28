import { OrderDetail } from './orderdetail';

export class Order {
  userName: string;
  shipAddress: string;
  shipEmail: string;
  shipPhoneNumber: string;
  orderDetails : OrderDetail[] ;
}

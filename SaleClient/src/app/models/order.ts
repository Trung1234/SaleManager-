import { OrderDetail } from './orderdetail';

export class Order {
  shipName: string;
  shipAddress: string;
  shipEmail: string;
  shipPhoneNumber: string;
  totalPrice: number;
  orderDetails : OrderDetail[] ;
}

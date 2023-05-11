import {AxiosResponse} from 'axios';
import $api from '../http';
import {IOrder} from '../models/IOrder';
import {IOrderDetail} from '../models/IOrderDetail';

export default class OrderService {
    static async getAll(): Promise<AxiosResponse<IOrder[]>> {
        return $api.get(`Order`) as Promise<AxiosResponse<IOrder[]>>;
    }

    static async getAllDetails(): Promise<AxiosResponse<IOrderDetail[]>> {
        return $api.get(`Order`) as Promise<AxiosResponse<IOrderDetail[]>>;
    }

    static async getById( id:number): Promise<AxiosResponse<IOrderDetail>> {
        return $api.get(`Order/id`, {params: {id:id}}) as Promise<AxiosResponse<IOrderDetail>>;
    }

    static async create( order:IOrder): Promise<AxiosResponse<IOrder>> {
        return $api.post(`Order`, order) as Promise<AxiosResponse<IOrder>>;
    }

    static async update( order:IOrder): Promise<AxiosResponse<IOrder>> {
        return $api.put(`Order`, order) as Promise<AxiosResponse<IOrder>>;
    }
}
import {AxiosResponse} from 'axios';
import $api from '../http';
import {IOrder} from '../models/IOrder';

export default class OrderService {
    static async getAll(): Promise<AxiosResponse<IOrder[]>> {
        return $api.get(`Order`) as Promise<AxiosResponse<IOrder[]>>;
    }

    static async create( order:IOrder): Promise<AxiosResponse<IOrder>> {
        return $api.post(`Order`, order) as Promise<AxiosResponse<IOrder>>;
    }
}
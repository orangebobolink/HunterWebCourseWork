import {AxiosResponse} from 'axios';
import $api from '../http';
import {IOrder} from '../models/IOrder';

export default class RoleService {
    static async addRole(email:string, role:string): Promise<AxiosResponse<IOrder[]>> {
        return $api.get(`Order`) as Promise<AxiosResponse<IOrder[]>>;
    }

    static async deleteRole(email:string, role:string): Promise<AxiosResponse<IOrder>> {
        return $api.post(`Order`) as Promise<AxiosResponse<IOrder>>;
    }
}
import {AxiosResponse} from 'axios';
import $api from '../http';
import {IUserDetail} from '../models/IUserDetail';

export default class UserService {
    static async getAll(): Promise<AxiosResponse<IUserDetail[]>> {
        return $api.get(`User`) as Promise<AxiosResponse<IUserDetail[]>>;
    }

    static async getByEmail(email:string): Promise<AxiosResponse<IUserDetail>> {
        return $api.get(`User/email`, {params: {name:email}}) as Promise<AxiosResponse<IUserDetail>>;
    }

    static async update( user:IUserDetail): Promise<AxiosResponse<IUserDetail>> {
        return $api.put(`User`, user) as Promise<AxiosResponse<IUserDetail>>;
    }
}
import {AxiosResponse} from 'axios';
import $api from '../http';

export default class RoleService {
    static async getAll(): Promise<AxiosResponse<string[]>> {
        return $api.get(`Role`) as Promise<AxiosResponse<string[]>>;
    }
}
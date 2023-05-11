import {AxiosResponse} from 'axios';
import $api from '../http';
import {IStatus} from '../models/IStatus';

export default class StatusService {
    static async getAll(): Promise<AxiosResponse<IStatus[]>> {
        return $api.get(`Status`) as Promise<AxiosResponse<IStatus[]>>;
    }
}
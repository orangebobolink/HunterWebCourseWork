import {AxiosResponse} from 'axios';
import $api from '../http';
import {IFeedback} from '../models/IFeedback';

export default class MessangerService {
    static async getAll(): Promise<AxiosResponse<string[]>> {
        return $api.get(`Messanger`) as Promise<AxiosResponse<string[]>>;
    }
}
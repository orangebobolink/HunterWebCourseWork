import {AxiosResponse} from 'axios';
import $api from '../http';
import {IFeedback} from '../models/IFeedback';

export default class FeedbackService {
    static async getAll(): Promise<AxiosResponse<IFeedback[]>> {
        return $api.get(`Feedback`) as Promise<AxiosResponse<IFeedback[]>>;
    }
}
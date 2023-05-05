import $api from '../http';
import {AxiosResponse} from 'axios';
import {IAuthRepsponse} from '../models/response/IAuthRepsponse';

export default class AuthService {
    static async login(email: string, password: string): Promise<AxiosResponse<IAuthRepsponse>> {
        return $api.post<IAuthRepsponse>('Auth/login', {email, password});
    }

    static async registration(email: string, password: string): Promise<AxiosResponse<IAuthRepsponse>> {
        return $api.post<IAuthRepsponse>('Auth/registration', {email, password});
    }

    static async logout(): Promise<void> {
        return $api.post('Auth/logout');
    }
}


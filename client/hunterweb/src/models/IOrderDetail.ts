export interface IOrderDetail {
    id:number;
    userEmail: string;
    numberHunters: number;
    countDates:number;
    includeHouse:boolean;
    additionalInfo:string;
    filingDate:Date;
    animalInfo:string;
    statusName:string;
}
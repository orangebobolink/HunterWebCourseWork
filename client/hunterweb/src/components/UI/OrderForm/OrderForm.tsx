import React, {useContext, useState} from 'react';
import InputField from '../InputField/InputField';
import {Context} from '../../../index';
import {Button, Checkbox, Label, Textarea} from 'flowbite-react';
import OrderService from '../../../services/OrderService';
import {IOrder} from '../../../models/IOrder';

const OrderForm = () => {
    const {store} = useContext(Context);

    const [numberHunters, setNumberHunters] = useState(1)
    const [countDates, setCountDates] = useState(1)
    const [includeHouse, setIncludeHouse] = useState(false)
    const [additionalInfo, setAdditionalInfo] = useState("")
    const [animalInfo, setAnimalInfo] = useState("")

    return (
        <form className="container mx-auto w-1/3 flex flex-col gap-4 max-w-7xl"
              onSubmit={
                  ()=> {
                      const order:IOrder = {
                          id:0,
                          userEmail:store.user.email,
                          numberHunters:numberHunters,
                          countDates:countDates,
                          includeHouse:includeHouse,
                          additionalInfo:additionalInfo,
                          animalInfo:animalInfo
                      }
                      debugger
                      OrderService.create(order);
                  }
              }
        >

            <InputField id="email1" type="text" required={true} labelValue="Животные"
                        onChange={(e: any) => setAnimalInfo(e.target.value)}
                        value={animalInfo}
            />

            <InputField id="email1" type="number" required={true} labelValue="Количество охотников"
                        onChange={(e: any) => setNumberHunters(e.target.value)}
                        value={numberHunters}
                        min={1}
                        max={15}
            />

            <InputField id="email1" type="number" required={true} labelValue="Количество дней"
                        onChange={(e: any) => setCountDates(e.target.value)}
                        value={countDates}
                        min={1}
                        max={10}
                        readonly={true}
            />

            <div className="flex items-center gap-2">
                <Checkbox id="agree" required={false} onChange={(e: any) => setIncludeHouse(!includeHouse)}/>
                <Label htmlFor="agree">
                    Включить проживание

                </Label>
            </div>

            <div id="textarea">
                <div className="mb-2 block">
                    <Label
                        htmlFor="comment"
                        value="Дополнительная информация"
                    />
                </div>
                <Textarea
                    id="comment"
                    placeholder="Leave a comment..."
                    required={false}
                    rows={4}
                    onChange={(e: any) => setAdditionalInfo(e.target.value)}
                    value={additionalInfo}
                />
            </div>

            <Button className="w-1/2 self-center" type="submit">
                Отправить
            </Button>
        </form>
    );
};

export default OrderForm;
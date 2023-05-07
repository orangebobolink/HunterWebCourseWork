import React, {FC} from 'react';
import {Rating} from 'flowbite-react';

interface Props {
    countFillStar: number,
    countStar:number
}

const StarRaiting : FC<Props> = ({countFillStar, countStar}) => {
    return (
        <Rating>
            {
                [...Array(countStar)].map((star, index) => {
                    let flag = false;
      
                    if(index < countStar - 1)
                        flag = true

                    return (
                        <Rating.Star key={index} filled={flag}/>
                    );
                })
            }
        </Rating>
    );
};

export default StarRaiting;
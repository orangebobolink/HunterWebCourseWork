import React, {FC} from 'react';
import {IFeedback} from '../../../models/IFeedback';
import StarRaiting from '../StarRaiting/StarRaiting';

interface Props {
    feedback: IFeedback
}

const Feedback:FC<Props> = ({feedback}) => {
    return (
        <div className="py-8 px-12 mb-12 bg-gray-50 border-b border-gray-100 transform transition duration-300 ease-in-out hover:-translate-y-2"

        >
            <blockquote className="max-w-2xl mx-auto mb-4 text-gray-500 lg:mb-8 dark:text-gray-400">
                <h3 className="text-lg font-semibold text-gray-900 dark:text-white">
                    <StarRaiting countFillStar={feedback.mark} countStar={5}/>
                </h3>
                <p className="my-4">{feedback.content}</p>
            </blockquote>
            <figcaption className="flex items-center justify-center space-x-3">

                    <div className="space-y-0.5 font-medium dark:text-white text-left">
                        <div>{feedback.userFirstName}</div>
                        <div className="text-sm text-gray-500 dark:text-gray-400"> {feedback.dateCreate.toString()}</div>
                    </div>
            </figcaption>
        </div>


    );
};

export default Feedback;
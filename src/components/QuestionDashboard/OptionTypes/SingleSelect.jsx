import { ChoiceInput } from '../Input/ChoiceInput';
import { FaRegCheckCircle, FaRegTrashAlt } from 'react-icons/fa';
import { AddChoiceInput } from '../Input/AddChoiceInput';
import { useDispatch, useSelector } from 'react-redux';
import { deleteChoiceHandler, setAnswer } from '../../../redux/uploadDBSlice';

export const SingleSelect = () => {
  const { choices, answer } = useSelector(s => s.uploadDB);
  const dispatch = useDispatch();

  return (
    <div className="choices-container">
      <AddChoiceInput />
      {choices?.map((c, i) => (
        <ChoiceInput
          key={c.oID}
          label={'Choice ' + (i + 1)}
          choice={c}
        >
          <FaRegCheckCircle
            size={16}
            onClick={() => dispatch(setAnswer(c))}
            className={`btn s-check ${answer?.oID === c.oID ? 'selected' : ''}`}
          />
          <FaRegTrashAlt
            size={16}
            onClick={() => dispatch(deleteChoiceHandler(c.oID))}
            className="btn trash"
          />
        </ChoiceInput>
      ))}
    </div>
  );
};

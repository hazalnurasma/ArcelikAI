import { useDispatch } from "react-redux";
import { hideModal, setModalContext, setWindowContent } from "../../redux/windowSlice";
import { postQuestionResponses } from "../../api";
import { useSelector } from "react-redux";

const WindowTabs = ({ tabs, selectedContent, lastCompleted, onSelect, content }) => {
  const tabName = content === "quiz" ? "Question" : "Video";
  const dispatch = useDispatch();
  const isDisabled = (id) => {
    return content === "quiz" ? false : (id > lastCompleted + 1)
  }
  const { responses, responsesToBeSended } = useSelector(state => state.quiz);
  const user = useSelector(state => state.user);

  const sendQuizHandler = () => {
    const sendQuiz = async () => {
      try {
        await postQuestionResponses(user.accessToken, responsesToBeSended);
        console.log('responsesToBeSended:; ', responsesToBeSended);
      } catch (error) {
        throw error;
      }
    };
    sendQuiz();
  }

  const showModal = () => {
    dispatch(setModalContext({
      title: "Submit",
      description: "Do you want to submit your answers?",
      disabled: false,
      buttonA: "Cancel",
      actionA: () => dispatch(hideModal()),
      buttonB: "Submit",
      actionB: sendQuizHandler,
      // actionB: () => console.log("Quiz was sent"),
      // actionB: () => setIsPaused(true),
    }))
  }

  return (
    <div className="window-tabs">
      <div className='tabs'>
      {tabs.map((t) => (
        <button
          key={t.Id}
          className={`v-btn ${selectedContent === t.Id ? "selected-content" : ""}`}
          onClick={() => onSelect(t.Id)}
          disabled={isDisabled(t.Id)}
        >
          { tabName } {t.Id}
        </button>
      ))}
      </div>
      {content === "quiz" && <button className="submit-button" onClick={showModal}>Submit</button>}
      {content === "video" && <button className="quiz-button">Quiz</button>}
    </div>
  );
};

export default WindowTabs;

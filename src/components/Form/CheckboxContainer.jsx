import "./CheckBoxContainer.css";

function CheckBoxContainer({ state, handleInputChange }) {
  //Step 2 - Knowledgebase & PDF upload checkboxes
  return (
    <div className="checkbox-container">
      <div className="cb-1">
        <input
          id="cb1"
          type="checkbox"
          checked={state.cb1}
          onChange={(e) => handleInputChange("cb1", !state.cb1)}
        />
        <label htmlFor="cb1">Use knowledgebase</label>
      </div>
      <div className="cb-2">
        <input
          id="cb2"
          type="checkbox"
          checked={state.cb2}
          onChange={(e) => handleInputChange("cb2", !state.cb2)}
        />
        <label htmlFor="cb2">Enable uploading PDF Files</label>
      </div>
    </div>
  );
}

export default CheckBoxContainer;

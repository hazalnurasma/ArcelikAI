import { useState, useEffect } from 'react';
import './VideoPool.css';
import { CiEdit, CiTrash } from "react-icons/ci";
import { IoCheckmarkOutline } from "react-icons/io5";
import { fetchVideoNamesFromDatabase } from '../../../api';
import { deleteVideoFromDatabase } from '../../../api';



const VideoPool = () => {
  const [currentPage, setCurrentPage] = useState(1); 
  const videosPerPage = 10; 
  const [editingIndex, setEditingIndex] = useState(-1);
  const [editedName, setEditedName] = useState('');
  const [allVideos, setAllVideos] = useState(['adres gezgini',]);

  useEffect(() => {
    const fetchVideos = async () => {
      try {
        const videoNames = await fetchVideoNamesFromDatabase();
        setAllVideos(videoNames);
      } catch (error) {
        console.error('Error fetching videos:', error);
      }
    };

    fetchVideos();
  }, []);

  // video list of current page
  const indexOfLastVideo = currentPage * videosPerPage;
  const indexOfFirstVideo = indexOfLastVideo - videosPerPage;
  const currentVideos = allVideos.slice(indexOfFirstVideo, indexOfLastVideo);

  // change page number
  // const paginate = (pageNumber) => setCurrentPage(pageNumber);

  // video deleting func
  const handleDelete = async (index) => {
    try {
      const videoToDelete = allVideos[indexOfFirstVideo + index];
      await deleteVideoFromDatabase(videoToDelete.id);
      // if deleting is successful then remove the video name from the list
      const updatedVideos = [...allVideos];
      updatedVideos.splice(indexOfFirstVideo + index, 1);
      setAllVideos(updatedVideos);

      // pagination devre dışı old. için işe yaramaz
      // if (currentVideos.length === 1 && currentPage > 1) {
      //   setCurrentPage(currentPage - 1);
      // }
    } catch (error) {
      console.error('Error deleting video:', error);
    }
  };


  const handleEdit = (index) => {
    setEditingIndex(indexOfFirstVideo + index);
    setEditedName(allVideos[indexOfFirstVideo + index]);
  };

  const handleSaveEdit = (index) => {
    const updatedVideos = [...allVideos];
    updatedVideos[indexOfFirstVideo + index] = editedName;
    setAllVideos(updatedVideos);
    setEditingIndex(-1);
  };

  return (
    <div className='Container'>
      <div className='titles'>
        <h1 className='first-title'>All Videos</h1>
        <h2 className='second-title'>View and browse all videos, edit video details, secure video deletion. All in one.</h2>
      </div>
      <div className="video-pool">
        <div className="video-list">
          {currentVideos.map((video, index) => (
            <div className="video-item" key={index}>
              {editingIndex === index + indexOfFirstVideo ? (
                <div className="edit-container">
                  <input
                    className='input-field'
                    type="text"
                    value={editedName}
                    onChange={(e) => setEditedName(e.target.value)}
                  />
                  <IoCheckmarkOutline 
                    className="done-icon"
                    size='1.7rem'
                    cursor='pointer'
                    onClick={() => handleSaveEdit(index)}
                  />
                </div>
              ) : (
                <span>{video}</span>
              )}
              <div className="item-pack">
                <CiEdit
                  className='item'
                  size='1.7rem'
                  cursor='pointer'
                  onClick={() => handleEdit(index)}
                />
                <CiTrash
                  className='item-2'
                  size='1.7rem'
                  cursor='pointer'
                  onClick={() => handleDelete(index)}
                />
              </div>
            </div>
          ))}
        </div>
        {/* <div className="pagination">
          {[...Array(Math.ceil(allVideos.length / videosPerPage)).keys()].map((number) => (
            <div key={number} onClick={() => paginate(number + 1)} className="page-number">
              {number + 1}
            </div>
          ))}
        </div> */}
      </div>
    </div>
  );
};

export default VideoPool;

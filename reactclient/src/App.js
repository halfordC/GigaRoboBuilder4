import React, { useState } from "react";
import Constants from "./Utilities/Constants"
import PostCreateForm from "./Components/PostCreateForm"
import PostUpdateForm from "./Components/PostUpdateForm"

export default function App() {
  const [robots, setRobots] = useState([]);
  const [showingCreateNewPostForm, setShowingCreateNewPostForm] = useState(false);
  const [postCurrentlyBeingUpdated, setPostCurrentlyBeingUpdated] = useState(null);

  function getRobots() {
    const url = Constants.API_URL_GET_ALL_ROBOTS;

    fetch(url, {
      method: 'GET'
    })
      .then(response => response.json())
      .then(robotsFromServer => {
        setRobots(robotsFromServer);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  }

  function deletePost(postId) {
    const url = `${Constants.API_URL_DELETE_POST_BY_ID}/${postId}`;

    fetch(url, {
      method: 'DELETE'
    })
      .then(response => response.json())
      .then(responseFromServer => {
        console.log(responseFromServer);
        onPostDeleted(postId);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });

  }

  return (
    <div className="container">
      <div className="row min-vh-100">
        <div className="col d-flex flex-column justify-content-center align-items-center">
          {(showingCreateNewPostForm === false && postCurrentlyBeingUpdated === null) && (
            <div>
              <h1>ASP .NET Core React Tutorial</h1>
              <div className="mt-5">
                <button onClick={getPosts} className="btn btn-dark btn-lg w-100">Get Posts from server</button>
                <button onClick={() => setShowingCreateNewPostForm(true)} className="btn btn-secondary btn-lg w-100 mt-4">Create Post</button>
              </div>
            </div>
          )}

          {(posts.length > 0 && showingCreateNewPostForm === false && postCurrentlyBeingUpdated === null) && renderPostsTable()}

          {showingCreateNewPostForm && <PostCreateForm onPostCreated={onPostCreated} />}

          {postCurrentlyBeingUpdated !== null && <PostUpdateForm post={postCurrentlyBeingUpdated} onPostUpdated={onPostUpdated} />}
        </div>
      </div>
    </div>
  );

  function renderPostsTable() {
    return (
      <div className="table-responsive mt-5">
        <table className="table table-bordered border-dark">
          <thead>
            <tr>
              <th scope="col">PostId (PK)</th>
              <th scope="col">Title</th>
              <th scope="col">Content</th>
              <th scope="col">Crud Operations</th>
            </tr>
          </thead>
          <tbody>
            {robots.map((robot) => (
              <tr key={robot.id}>
                <th scope="row">{robot.id}</th>
                <td>{post.title}</td>
                <td>{post.content}</td>
                <td>
                  <button onClick={() => setPostCurrentlyBeingUpdated(post)} className="btn btn-dark btn-lg mx-3 my-3">Update</button>
                  <button onClick={() => {
                    if (window.confirm(`Are you sure you want to delete the post "${post.title}"?`)) {
                      deletePost(post.postId)
                    } 
                  }} className="btn btn-secondary btn-lg">Delete</button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>

        <button onClick={() => setPosts([])} className="btn btn-dark btn-lg w-100">Clear Posts</button>
      </div>
    )
  }

  function onPostCreated(createdPost) {
    setShowingCreateNewPostForm(false);

    if (createdPost === null) {
      return;
    }

    alert('Post successfully creatd. After clicking OK, your new post titled "${createdPost.title}" will show up in the table below. ');

    getPosts();

  }

  function onPostUpdated(updatedPost) {
    setPostCurrentlyBeingUpdated(null);
    if (updatedPost === null) {
      return;
    }

    let postCopy = [...posts];

    const index = postCopy.findIndex((postCopyPost, currentIndex) => {
      if (postCopyPost.postId === updatedPost.postId) {
        return true;
      }
    });

    if (index !== -1) {
      postCopy[index] = updatedPost;
    }

    setPosts(postCopy);

    alert(`Post successfully updated. After clicking OK, look for teh post with the title "${updatedPost.title}" in the table below to see the updates.`);

  }

  function onPostDeleted(deletedPostPostId) {
    let postsCopy = [...posts];

    const index = postsCopy.findIndex((postCopyPost, currentIndex) => {
      if (postCopyPost.postId === deletedPostPostId) {
        return true;
      }
    });

    if (index !== -1) {
      postsCopy.splice(index, 1);
    }

    setPosts(postsCopy);
    alert(`Post successfully deleted. After clicking OK, look at the table below to (not) see your post disapear.`);
  }

}

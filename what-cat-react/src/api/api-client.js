const BASE_URL = 'https://localhost:5001/Cat/';

export const apiClient = {
  getCat(name) {
    console.log('Fetching your cat');
    /* return Promise.resolve([
      {
        id: 1,
        name: 'Feed cat',
        isComplete: true
      },
      {
        id: 2,
        name: 'Save world',
        isComplete: false
      }
    ]); */
    return fetch(BASE_URL+name).then(result => result.json());
  },

/*   createTask(task) {
    const serverTask = Object.assign({}, task);
    delete serverTask.id;
    console.log('Create a new task');
    return fetch(BASE_URL, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(serverTask)
    }).then(result => result.json());
  },

  removeTask(task) {
    console.log('Removing task');
    return fetch(`${BASE_URL}/${task.id}`, {
      method: 'DELETE',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(task)
    });
  },

  updateTask(task) {
    console.log('Updating task');
    return fetch(`${BASE_URL}/${task.id}`, {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(task)
    });
  } */
};

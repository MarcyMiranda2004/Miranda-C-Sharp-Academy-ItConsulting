//#region === SET IMPOSTAZIONI BASE ===
const express = require("express");
const cors = require("cors");
const bodyParser = require("body-parser");
const database = require("./database.js");

const application = express();
const port = 8080;

const apiTest = `/api/test`;
const apiTasks = `/api/tasks`;
//#endregion

//#region === TEST DELL'ENDPOINT PER LA CONNESSIONE ===
application.use(
  cors({
    origin: "*",
  })
);
application.use(bodyParser.json());
//#endregion

//#region === FALLBACK TASK (SE SQL NON È DISPONIBILE)
let fallbackTasks = [
  {
    id: 1,
    title: "Task di Test 1",
    description: "Prima task di esempio senza MySQL",
    completed: false,
  },
  {
    id: 2,
    title: "Task di Test 2",
    description: "Seconda task di esempio",
    completed: true,
  },
  {
    id: 3,
    title: "Connessione Unity",
    description: "Test della connessione da Unity",
    completed: false,
  },
];
//#endregion

//#region === ENDPOINT PER LE TASKS

//#region GET ENDPOINT PER LA CONNESSIONE
application.get(`${apiTest}`, (request, response) => {
  response.json({
    message: "server in esecuzione",
    timestamp: new Date().toString(),
  });
});
//#endregion

//#region GET DI TUTTE TASKS
application.get(`${apiTasks}`, async (request, response) => {
  try {
    const [tasks] = await database.execute(
      "SELECT * FROM tasks ORDER BY id DESC"
    );
    response.json(tasks);
  } catch (error) {
    console.log("MySql non disponibile, utilizzo fallback:", error.message);
    response.json(fallbackTasks);
  }
});
//#endregion

//#region GET TASK SINGOLA
application.get(`${apiTasks}/:id`, async (request, response) => {
  try {
    const [tasks] = await database.execute("SELECT * FROM tasks WHERE id = ?", [
      request.params.id,
    ]);
    if (tasks.length === 0) {
      return response.status(404).json({ error: "Task non trovata" });
    }
    response.json(tasks[0]);
  } catch (error) {
    response.status(500).json({
      error: "Errore nel recupero task",
      details: error.message,
    });
  }
});
//#endregion

//#region POST NUOVA TASK
application.post(`${apiTasks}`, async (req, res) => {
  try {
    const { title, description, completed = false } = req.body;

    if (!title) {
      return res
        .status(400)
        .json({ error: "Inserisci un titolo obbligatorio" });
    }

    const [result] = await database.execute(
      "INSERT INTO tasks (title, description, completed) VALUES (?, ?, ?)",
      [title, description || "", completed]
    );

    const [newTask] = await database.execute(
      "SELECT * FROM tasks WHERE id = ?",
      [result.insertId]
    );
    res.status(201).json(newTask[0]);
  } catch (error) {
    console.log(
      "⚠️ MySQL non disponibile per POST, uso fallback:",
      error.message
    );

    const { title, description, completed = false } = req.body;

    if (!title) {
      return res.status(400).json({ error: "Il titolo è obbligatorio" });
    }

    const newTask = {
      id: Math.max(...fallbackTasks.map((t) => t.id), 0) + 1,
      title,
      description: description || "",
      completed,
    };

    fallbackTasks.push(newTask);
    res.status(201).json(newTask);
  }
});
//#endregion

//#region PUT UPDATE TASK
application.put(`${apiTasks}/:id`, async (request, response) => {
  try {
    const { title, description, completed } = request.body;
    const taskId = request.params.id;

    const [result] = await database.execute(
      "UPDATE tasks SET title = ?, description = ?, completed = ? WHERE id = ?",
      [title, description, completed, taskId]
    );

    if (result.affectedRows === 0) {
      return response.status(404).json({ error: "Task non trovata" });
    }

    const [updatedTask] = await database.execute(
      "SELECT * FROM tasks WHERE id = ?",
      [taskId]
    );
    response.json(updatedTask[0]);
  } catch (error) {
    response.status(500).json({
      error: "Errore nell'aggiornamento della task",
      details: error.message,
    });
  }
});
//#endregion

//#region DELETE TASK
application.delete(`${apiTasks}/:id`, async (request, response) => {
  try {
    const [result] = await database.execute("DELETE FROM tasks WHERE id = ?", [
      request.params.id,
    ]);

    if (result.affectedRows === 0) {
      return response.status(404).json({ error: "Task non trovata" });
    }

    response.json({ message: "Task eliminata" });
  } catch (error) {
    response.status(500).json({
      error: "Errore nell'eliminazione della task",
      details: error.message,
    });
  }
});
//#endregion

//#region LISTA ENDPOINT TASKS
application.listen(port, () => {
  console.log();
  console.log(`\x1b[32m[Status] [OK]\x1b[0m`);
  console.log(`Server Node.js in ascolto su http://localhost:${port}`);
  console.log(`Endpoints disponibili:`);
  console.log(`- GET ${apiTest} - test di connessione rapido`);
  console.log(`- GET ${apiTasks} - Ottieni tutte le tasks`);
  console.log(`- GET ${apiTasks}/:id - Ottieni una task specifica`);
  console.log(`- POST ${apiTasks} - Crea una nuova task`);
  console.log(`- PUT ${apiTasks}/:id - Aggiorna una task`);
  console.log(`- DELETE ${apiTasks}/:id - Elimina una task`);
});
//#endregion
//#endregion

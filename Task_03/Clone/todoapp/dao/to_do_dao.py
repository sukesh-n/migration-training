import sqlite3

from typing import List
from dataclasses import dataclass

@dataclass
class Todo:
	todo_id: int
	title: str
	description: str
	completed: bool

class TodoDao:
	def __init__(self, db_file: str):
		self.conn = sqlite3.connect(db_file)
		self.cursor = self.conn.cursor()

	def create_table(self):
		self.cursor.execute('''
			CREATE TABLE IF NOT EXISTS todos (
				todo_id INTEGER PRIMARY KEY AUTOINCREMENT,
				title TEXT NOT NULL,
				description TEXT,
				completed INTEGER DEFAULT 0
			)
		''')
		self.conn.commit()

	def insert_todo(self, todo: Todo):
		self.cursor.execute('''
			INSERT INTO todos (title, description, completed)
			VALUES (?, ?, ?)
		''', (todo.title, todo.description, todo.completed))
		self.conn.commit()

	def select_todo_by_id(self, todo_id: int) -> Todo:
		self.cursor.execute('''
			SELECT * FROM todos WHERE todo_id = ?
		''', (todo_id,))
		row = self.cursor.fetchone()
		if row:
			return Todo(*row)
		return None

	def select_all_todos(self) -> List[Todo]:
		self.cursor.execute('''
			SELECT * FROM todos
		''')
		rows = self.cursor.fetchall()
		return [Todo(*row) for row in rows]

	def delete_todo_by_id(self, todo_id: int) -> bool:
		self.cursor.execute('''
			DELETE FROM todos WHERE todo_id = ?
		''', (todo_id,))
		self.conn.commit()
		return self.cursor.rowcount > 0

	def update_todo(self, todo: Todo) -> bool:
		self.cursor.execute('''
			UPDATE todos SET title = ?, description = ?, completed = ?
			WHERE todo_id = ?
		''', (todo.title, todo.description, todo.completed, todo.todo_id))
		self.conn.commit()
		return self.cursor.rowcount > 0
import mysql.connector

from mysql.connector import Error

class LoginDao:
	def validate(self, loginBean):
		status = False

		try:
			connection = mysql.connector.connect(
				host='localhost',
				database='your_database',
				user='your_username',
				password='your_password'
			)

			if connection.is_connected():
				cursor = connection.cursor()
				query = "SELECT * FROM users WHERE username = %s AND password = %s"
				cursor.execute(query, (loginBean.getUsername(), loginBean.getPassword()))

				if cursor.fetchone():
					status = True

		except Error as e:
			print("Error while connecting to MySQL", e)

		finally:
			if connection.is_connected():
				cursor.close()
				connection.close()

		return status

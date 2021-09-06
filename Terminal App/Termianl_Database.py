import sqlite3
from sqlite3 import Error

class Database:
    def __init__(self, path):
        self.connection = None
        self.create_user_tabel = """
                CREATE TABLE IF NOT EXISTS users (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    FirstName TEXT NULL,
                    SecondName TEXT NULL,
                    BirthDate INTEGER NULL,
                    Email TEXT,
                    Hobby TEXT,
                    Password TEXT
                );
                """
        try:
            self.connection = sqlite3.connect(path)
            self.cursor = self.connection.cursor()
            self.cursor.execute(self.create_user_tabel)
            self.connection.commit()
            print("The Database is created and ready to go")
        except Error as e:
            print(f"The error '{e}' occurred")

    def Selecting(self):
        try:
            self.cursor.execute("SELECT * FROM users")
            result = self.cursor.fetchall()
            return result
        except Error as e:
            print(f"The error '{e}' occurred")


    def Inserting(self, List):
        if len(List) < 6:
            HowLong = 6 - len(List)
            for i in range(HowLong):
                List.append("")
        try:
            self.cursor.execute("INSERT INTO users(FirstName, SecondName, BirthDate, Email, Hobby, Password) VALUES (?, ?, ?, ?, ?, ?)", (List[0], List[1], List[2], List[3], List[4], List[5]))
            self.connection.commit()
            print("Query executed successfully")
        except Error as e:
            print(f"The error '{e}' occurred")


    def Modyfiaction(self, Which, Value, Position):
        if Which == "FirstName":
            try:
                self.cursor.execute("UPDATE users SET FirstName = (?) WHERE id = (?)", (Value, Position))
                self.connection.commit()
                print("Query executed successfully")
            except Error as e:
                print(f"The error '{e}' occurred")
        elif Which == "SecondName":
            try:
                self.cursor.execute("UPDATE users SET SecondName = (?) WHERE id = (?)", (Value, Position))
                self.connection.commit()
                print("Query executed successfully")
            except Error as e:
                print(f"The error '{e}' occurred")
        elif Which == "BirthDate":
            try:
                self.cursor.execute("UPDATE users SET BirthDate = (?) WHERE id = (?)", (Value, Position))
                self.connection.commit()
                print("Query executed successfully")
            except Error as e:
                print(f"The error '{e}' occurred")
        elif Which == "Email":
            try:
                self.cursor.execute("UPDATE users SET Email = (?) WHERE id = (?)", (Value, Position))
                self.connection.commit()
                print("Query executed successfully")
            except Error as e:
                print(f"The error '{e}' occurred")
        elif Which == "Hobby":
            try:
                self.cursor.execute("UPDATE users SET Hobby = (?) WHERE id = (?)", (Value, Position))
                self.connection.commit()
                print("Query executed successfully")
            except Error as e:
                print(f"The error '{e}' occurred")
        elif Which == "Password":
            try:
                self.cursor.execute("UPDATE users SET Password = (?) WHERE id = (?)", (Value, Position))
                self.connection.commit()
                print("Query executed successfully")
            except Error as e:
                print(f"The error '{e}' occurred")
        else:
            print("Something went wrong")

    def Deleting(self, Position):
        try:
            self.cursor.execute("DELETE FROM users WHERE id = (?)", (Position,))
            self.connection.commit()
            print("Query executed successfully")
        except Error as e:
            print(f"The error '{e}' occurred")

Database_Obj = Database("Database.db")

Choice = 0
while Choice != 5:
    print("What you want? 1 - Inserting new record; 2 - Modify record; 3 - Deleting record; 4 - Showing database; 5 - Exit app")
    print("What columns are in database: FirstName, SecondName, BrithDate, Email, Hobby, Password")
    Choice = int(input())
    if Choice == 1:
        List = [i for i in input().split()]
        Database_Obj.Inserting(List)
    elif Choice == 2:
        print("Give me: Which - column of record I must look; Value - what is new value; Position - which index I must change")
        List = [i for i in input().split()]
        try:
            Database_Obj.Modyfiaction(List[0], List[1], List[2])
        except:
            print("We got some issue")
    elif Choice == 3:
        print("Give me: Position - which index I must delete")
        Index = int(input())
        Database_Obj.Deleting(Index)
    elif Choice == 4:
        users = Database_Obj.Selecting()
        for i in users:
            print(i)
    elif Choice == 5:
        break
    else:
        print("Wrong number")
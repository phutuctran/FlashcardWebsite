import pyodbc
import base64
import pandas as pd

excel_file = 'dataset.xlsx'

# Đọc tệp Excel
data_frame = pd.read_excel(excel_file, usecols='A:I')

# In ra dữ liệu
script = "insert into Dictionary(WordText, Mean, IPA, SpeechPart, ThemeID, Level, Example, Author, Role) values("
for index, row in data_frame.iterrows():
    data = "";
    if (index >= 0 and index <=10):
        for column, value in row.items():
            if (column != 'stt' and column != 'tên ảnh ví dụ'):
                if (column == 'Nghĩa' or column == 'Phiên âm'):
                    data = data + "N'" + str(value) + "', ";
                else:
                    data = data + "'" + str(value) + "', ";
        #data = str(row['Từ']) + ', ' + str(row['Nghĩa']) + ', ' + str(row['Phiên âm']) + ', ' + str(row['Loại từ']) + ', ' + str(row['themeID']) + ', ' + str(row['Level']) + ', ' + str(row['Câu ví dụ']) 
        data = script + data + "'admin', 'A')"
        data = data.replace('\xa0', '')
        print(data)

'''
server = '.\SQLEXPRESS'
database = 'YVFlashCard'
# Kết nối đến cơ sở dữ liệu SQL Server
connection_string = f'DRIVER={{SQL Server}};SERVER={server};DATABASE={database}'
connection = pyodbc.connect(connection_string)
cursor = connection.cursor()
cursor.execute('select * from UserInfos')
results = cursor.fetchall()

print('ok')
# In kết quả
for row in results:
    print(row)
'''
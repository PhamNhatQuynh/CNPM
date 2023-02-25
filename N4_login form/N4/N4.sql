Create database Nhom4
Use Nhom4

Create table NhanVien(
	Ten nvarchar(30) NOT NULL,
	GioiTinh nvarchar(10),
	Email varchar(30) NOT NULL,
	QueQuan nvarchar(30) NOT NULL,
	SDT varchar(10) NOT NULL,
	MatKhau varchar(50) NOT NULL,

	constraint PK_NhanVien primary key(SDT)
)
Select * From NhanVien

Create Procedure insert_NhanVien(@Ten nvarchar(30),@GioiTinh nvarchar(10),@Email varchar(30),@QueQuan nvarchar(30),@SDT varchar(10),@MatKhau varchar(50))
As
Begin
	insert into NhanVien values(@Ten,@GioiTinh,@Email,@QueQuan,@SDT,@MatKhau)
end

Create Procedure search_QueQuan(@Quequan nvarchar(30))
AS
Begin
	Select * From NhanVien
	Where QueQuan = @Quequan
end

exec insert_NhanVien'Nguyen Van A','Nam','abc@gmail.com','TP.HCM','0123456789','nguyenvana'
exec insert_NhanVien'Nguyen Van B','Nu','abcd@gmail.com','Hà Nội','0987654321','nguyenvanb'
exec insert_NhanVien'Nguyen Van C','Nam','abc123@gmail.com','Huế','0154485258','nguyenb'
exec search_QueQuan'Hà Nội'

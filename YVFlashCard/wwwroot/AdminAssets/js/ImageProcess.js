function scaleImage(fileInput, img, maxWidth, maxHeight) {
    // Lấy file ảnh từ file input
    const file = fileInput.files[0];
    

    // Tạo đối tượng FileReader để đọc dữ liệu của file ảnh
    const reader = new FileReader();

    reader.onload = function (e) {
        // Tạo đối tượng Image để scale kích thước ảnh
        const imgObject = new Image();
        imgObject.src = e.target.result;

        imgObject.onload = function () {
            const canvas = document.createElement('canvas');
            const ctx = canvas.getContext('2d');

            // Tính tỷ lệ scale của ảnh
            let scale = 1;
            if (imgObject.width > maxWidth) {
                scale = maxWidth / imgObject.width;
            }
            if (imgObject.height > maxHeight) {
                const heightScale = maxHeight / imgObject.height;
                if (heightScale < scale) {
                    scale = heightScale;
                }
            }

            // Scale kích thước ảnh
            canvas.width = imgObject.width * scale;
            canvas.height = imgObject.height * scale;
            ctx.drawImage(imgObject, 0, 0, canvas.width, canvas.height);

            // Hiển thị ảnh đã scale lên thẻ img
            img.src = canvas.toDataURL('image/jpeg');

        };
    };

    reader.readAsDataURL(file);
}
function fileToByteArray(file) {
    return new Promise((resolve, reject) => {
        const reader = new FileReader();
        reader.onload = () => {
            const bytes = new Uint8Array(reader.result);
            resolve(bytes);
        };
        reader.onerror = reject;
        reader.readAsArrayBuffer(file.files[0]);
        
    });
}
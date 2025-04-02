# Sử dụng một image có Node.js
FROM node:23-alpine

# Đặt thư mục làm việc trong container
WORKDIR /app

# Copy package.json và cài đặt dependencies
COPY ["hospital.client/package.json", "./"]
RUN npm install

# Copy toàn bộ source code
COPY hospital.client/ ./

# Build ứng dụng
RUN npm run build

# Chạy ứng dụng với một HTTP server nhẹ (serve)
RUN npm install -g serve
CMD ["serve", "-s", "build"]

# Expose cổng 3000 (hoặc cổng khác nếu cần)
EXPOSE 3000

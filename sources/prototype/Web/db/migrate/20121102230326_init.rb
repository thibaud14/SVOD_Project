class Init < ActiveRecord::Migration
  def change
    create_table "collections", :force => true do |t|
      t.string   "name"
      t.integer  "year"
      t.datetime "created_at", :null => false
      t.datetime "updated_at", :null => false
    end

    create_table "genres", :force => true do |t|
      t.string   "name"
      t.datetime "created_at", :null => false
      t.datetime "updated_at", :null => false
    end

    create_table "langues", :force => true do |t|
      t.string   "name"
      t.datetime "created_at", :null => false
      t.datetime "updated_at", :null => false
    end

    create_table "users", :force => true do |t|
      t.string   "name"
      t.string   "email"
      t.string   "password_digest"
      t.datetime "created_at",      :null => false
      t.datetime "updated_at",      :null => false
    end

    create_table "reviews", :force => true do |t|
      t.string   "message"
      t.float    "star_rating"
      t.integer  "user_id"
      t.integer  "video_id"
      t.datetime "created_at",  :null => false
      t.datetime "updated_at",  :null => false
    end

    create_table "subtitles", :force => true do |t|
      t.string   "name"
      t.datetime "created_at", :null => false
      t.datetime "updated_at", :null => false
    end

    create_table "videos", :force => true do |t|
      t.string   "thumbnail_url"
      t.string   "type_video"
      t.string   "title"
      t.date     "year"
      t.integer  "duration"
      t.string   "country"
      t.string   "video_url"
      t.string   "bo_url"
      t.string   "synopsis"
      t.integer  "position"
      t.string   "tagline"
      t.float    "star_rating_avg"
      t.integer  "season"
      t.integer  "collection_id"
      t.datetime "created_at",      :null => false
      t.datetime "updated_at",      :null => false
    end

    create_table "genres_videos", :force => true do |t|
      t.integer   "video_id"
      t.integer   "genre_id"
    end

    create_table "langues_videos", :force => true do |t|
      t.integer   "video_id"
      t.integer   "langue_id"
    end

    create_table "subtitles_videos", :force => true do |t|
      t.integer   "video_id"
      t.integer   "subtitle_id"
    end

    create_table "users_videos", :force => true do |t|
      t.integer   "video_id"
      t.integer   "user_id"
    end
  end
end